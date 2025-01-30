function moveStuffAround(wiwi){

    let regbox = document.getElementById("register-box");
    let logbox = document.getElementById("login-box");
    console.log(regbox);
    if(wiwi == 0){
        regbox.classList.add("out");
        regbox.classList.remove("in");

        logbox.classList.add("in");
        logbox.classList.remove("out");
    }
    if(wiwi == 1){
        regbox.classList.add("in");
        regbox.classList.remove("out");

        logbox.classList.add("out");
        logbox.classList.remove("in");
    }
}