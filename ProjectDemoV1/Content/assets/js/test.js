function show(){
    var sol = document.getElementById('solution');
    var btn = document.getElementById('bShow');

    if (btn.innerHTML == "Xem lời giải"){
        sol.style.display = 'block';
        btn.innerHTML = 'Ẩn lời giải';
    }else{
        sol.style.display = 'none';
        btn.innerHTML = 'Xem lời giải';
    }

    console.log(sol);
    console.log(btn);
}
