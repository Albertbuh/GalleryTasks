import { useEffect, useRef } from "react";
import "./galleryItem.css";
function GalleryItem({ imageUrl }) {
  const canvasRef = useRef(null);

  useEffect(() => {
    const canvas = canvasRef.current;
    const ctx = canvas.getContext('2d');

    const img = new Image();
    img.src = imageUrl;

    img.onload = () => {
      canvas.width = img.width;
      canvas.height = img.height;
      ctx.drawImage(img, 0, 0);
    };
  }, [imageUrl]);

  function handleSaveFile() {
    const link = document.createElement('a');
    link.href = imageUrl;
    link.download = imageUrl;
    link.click();
  }

  return (
    <div className="container">
      <canvas ref={canvasRef} />
      <button onClick={handleSaveFile}>Save file</button>
    </div>
  );
}

export default GalleryItem;