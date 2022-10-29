// function show(){
//     var sol = document.getElementById('solution');
//     var btn = document.getElementById('bShow');

//     if (btn.innerHTML == "Xem lời giải"){
//         sol.style.display = 'block';
//         btn.innerHTML = 'Ẩn lời giải';
//     }else{
//         sol.style.display = 'none';
//         btn.innerHTML = 'Xem lời giải';
//     }
// }

function show(btn) {
    var elRightContent = btn.parentNode.getElementsByClassName("question_right_answer");
    if(elRightContent) {
        sol = elRightContent[0];
        if (btn.innerHTML == "Xem lời giải"){
            sol.style.display = 'block';
            btn.innerHTML = 'Ẩn lời giải';
        }else{
            sol.style.display = 'none';
            btn.innerHTML = 'Xem lời giải';
        }
    }


}

// function show1(){
//     var sol = document.getElementsByClassName('question_rigth_answer');
//     var btn = document.getElementsByClassName('showsolution');

//     if (btn.innerHTML == "Xem lời giải"){
//         sol.style.display = 'block';
//         btn.innerHTML = 'Ẩn lời giải';
//     }else{
//         sol.style.display = 'none';
//         btn.innerHTML = 'Xem lời giải';
//     }
// }