import { useState } from 'react';
import './termsOfUse.css';

function TermsOfUse({paragraphs, children}) {
    const [isAccepted, setIsAccepted] = useState(false);

    function handleAccept() {
        setIsAccepted(true);
    }

    if(isAccepted)
        return children;

    return(
        <div>
            <h1>Terms of use</h1>
            {paragraphs.map(paragraph => (
                <Paragraph 
                    title={paragraph.title}
                    text={paragraph.content || paragraph.text}/>
            ))}
            <button onClick={handleAccept}>Accept</button>
        </div>
    );
}

function Paragraph({title, text}) {
    return (
        <p>
            <h3>{title}</h3>
            <p>{text}</p>
        </p>
    )
}

export default TermsOfUse;