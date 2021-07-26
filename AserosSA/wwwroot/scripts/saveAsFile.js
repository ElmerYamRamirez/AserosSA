function saveAsFile(filename, bytesBase64) {
    var link = Document.createElement('a');
    link.download = filename;
    //link.href = "data:application/octec-stream;base64," + bytesBase64;
    link.href = "data:application/vnd.openxmlformats-pfficedocument.spreadsheetml.sheet;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}