const promiseStatus = {
    success: "success",
    error: "error"
};

async function getServerData(url) {
    const pathToTestFile = "/static/test.json";
    let response = await fetch(url + pathToTestFile);
    if (response.ok) {
        let result = await response.json();
        await acceptTermsOfUse(result.terms_of_use);
        result.images.forEach(async (image) => {
            const imageUrl = url + image.image_url;
            var rendering = await renderImageToCanvas(imageUrl);
            if (rendering.status === promiseStatus.success) {
                let div = document.createElement("div");
                div.classList.add("canvas-container");
                div.append(rendering.result);
                // let button = createSaveButtonForCanvas(rendering.result);
                let button = createSaveButtonForURL(imageUrl);
                div.append(button);
                document.body.append(div);
            }
        });
    }
}

function createSaveButtonForURL(imageUrl) {
    let button = document.createElement("button");
    button.innerHTML = "Save image";
    button.addEventListener('click', () => {
        const link = document.createElement('a');
        link.href = imageUrl;
        link.download = imageUrl;
        link.click();
    });
    // button.addEventListener('click', () => {
    //     fetch(url)
    //   .then(response => response.blob())
    //   .then(blob => {
    //     setFetching(false);
    //     const blobURL = URL.createObjectURL(blob);
    //     const a = document.createElement("a");
    //     a.href = blobURL;
    //     a.style = "display: none";

    //     if (name && name.length) a.download = name;
    //     document.body.appendChild(a);
    //     a.click();
    //   })
    //   .catch(() => setError(true));
    // })
    return button;
}

function createSaveButtonForCanvas(canvas) {
    let button = document.createElement("button");
    button.innerHTML = "Save image";
    button.addEventListener('click', () => {
        //not working because of taint canvas 
        const dataURL = canvas.toDataURL('image/png');
        const downloadLink = document.createElement('a');
        downloadLink.download = "test.png";
        downloadLink.href = dataURL;
        downloadLink.click();
    });
    return button;
}

async function renderImageToCanvas(imageUrl) {
    return new Promise((resolve, reject) => {
        let img = new Image();
        img.src = imageUrl;
        img.onload = () => {
            let canvas = document.createElement("canvas");
            canvas.width = img.width;
            canvas.height = img.height;
            canvas.getContext("2d").drawImage(img, 0, 0);
            resolve({
                status: promiseStatus.success,
                result: canvas
            })
        };

        img.onerror = () => {
            reject({
                status: promiseStatus.error,
                result: `Unable to load img ${imageUrl}`
            });
        }
    });
}

async function acceptTermsOfUse(termsOfUse) {
    termsOfUse.paragraphs.sort((a, b) => a.index - b.index);

    let parent = document.createElement("div");
    parent.insertAdjacentHTML('afterbegin', "<h1>Terms of use</h1>");

    termsOfUse.paragraphs.map(paragraph => {
        let child = document.createElement("p");
        child.innerHTML = `
            <h3>${paragraph.title}</h3>
            <p>${paragraph.content || paragraph.text}</p>
       `;
        parent.append(child);
    });

    let acceptButton = document.createElement("button");
    acceptButton.textContent = "Accept";
    parent.append(acceptButton);
    document.body.append(parent);

    return new Promise((resolve) => {
        acceptButton.onclick = () => {
            document.body.removeChild(parent);
            resolve({
                status: promiseStatus.success,
                result: "terms have been accepted"
            });
        }
    });
}

getServerData("http://188.166.203.164");
