import './App.css';
import { useState, useEffect } from 'react';
import TermsOfUse from './components/termsOfUse/termsOfUse';
import GalleryItem from './components/galleryItem/galleryItem';

function App() {
  const url = "http://188.166.203.164";
  const [termsOfUse, setTermsOfUse] = useState();
  const [images, setImages] = useState([]);

  useEffect(() => {
    async function getData() {
      const pathToTestFile = "/static/test.json";
      let response = await fetch(url + pathToTestFile);
      if (response.ok) {
        const result = await response.json();
        setTermsOfUse(result.terms_of_use);
        setImages(result.images);
      }
    }

    getData();
  }, []);

  if (!termsOfUse || !images)
    return <h1>Loading...</h1>;

  return (
    <div className="App">
      <TermsOfUse paragraphs={termsOfUse.paragraphs}>
        {images.map(image => (
          <GalleryItem key={image.image_url} imageUrl={url + image.image_url} />
          ))}
      </TermsOfUse>
    </div>
  );
}

export default App;
