$(document).ready(() => {
    $(".btthem").each((index, ele) => {
        $(ele).click(() => {
            var dem = 0;
            $(".ma").each((index, e) => {
                if ($(e).val() == $(ele).parent().parent().children(".first").text()) {
                    dem++;
                    console.log($(e).val())
                }
            })
            console.log($(ele).parent().parent().children(".first").text())
            if (dem == 0) {
                var newTr = `
                  <tr>
                    <td>
                      <input readonly name="MaSp" type="number" class="form-control ma" value="${$(ele).parent().parent().children(".first").text()}"/>
                    </td>
                    <td>${$(ele).parent().parent().children(".first").next().text()}</td>
                    <td>
                      <input class="form-control input-validation-error dongia" type="number" data-val="true" 
                      data-val-number="Đơn giá phải là số." data-val-range="Đơn giá nên có giá có giá trị từ 0" 
                      data-val-range-max="1.7976931348623157E+308" data-val-range-min="0" data-val-required="Đơn giá không được để trống" 
                      name="DonGia" value="${$(ele).parent().parent().children(".first").next().next().attr("data-price") * 1}" 
                        aria-describedby="DonGia-error" aria-invalid="true" min="0" required />
                    </td>
                    <td>
                      <input class="form-control input-validation-error soluong" type="number" data-val="true" 
                      data-val-range="Số lượng có nên có giá có giá trị lớn hơn 0" data-val-range-max="2147483647" 
                      data-val-range-min="1" data-val-required="Số lượng không được để trống" 
                      name="SoLuong" value="1" aria-describedby="SoLuong-error" aria-invalid="true" min="1" required />
                    </td>
                    <td class="thanhtien">
                      ${$(ele).parent().parent().children(".first").next().next().attr("data-price") * 1}
                    </td>
                    <td>
                      <button type="button" class="btn btn-danger btbo">Bỏ</button>
                    </td>
                  </tr>
                  `
                $("#dschon").append(newTr)
                tinhtongtien()
            }
        })
    })
    setInterval(() => {
        $(".dongia").each((index, ele) => {
            $(ele).on("input", () => {
                var thanhtien = $(ele).parent().next().next()
                thanhtien.text($(ele).val() * $(ele).parent().next().children().val())
                tinhtongtien()
            })
        })
        $(".soluong").each((index, ele) => {
            $(ele).on("input", () => {
                var thanhtien = $(ele).parent().next()
                thanhtien.text($(ele).val() * $(ele).parent().prev().children().val())
                tinhtongtien()
            })
        })
    }, 500)

    function tinhtongtien() {
        var tongtien = 0
        $(".thanhtien").each((index, elett) => {
            tongtien += $(elett).text() * 1
        })
        $("#tongtien").text(tongtien)
    }
    setInterval(() => {
        var btbo = document.querySelectorAll('.btbo')
        for (let i = 0; i < btbo.length; i++) {
            btbo[i].onclick = () => {
                var item_delete = document.querySelector(`#dschon>tr:nth-child(${i + 1})`)
                document.querySelector("#dschon").removeChild(item_delete)
                var tongtien = 0;
                var thanhtien = document.querySelectorAll(".thanhtien")
                for (var j = 0; j < thanhtien.length; j++) {
                    tongtien += thanhtien[j].innerText * 1
                }
                document.querySelector("#tongtien").innerText = tongtien
            }
        }
    }, 500)

})
