$("#file_upload").change((event) => {
    $("#img_hienthi").attr('src', URL.createObjectURL(event.target.files[0]))
})