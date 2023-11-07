$("#btnPdf").click(() => {
    var sHtml = $("#pdfContainer").html();
    sHtml = sHtml.replace(/</g, "StrTag").replace(/>/g, "EndTag");
    window.open(@url + "?html=" + sHtml, '_blank');
});