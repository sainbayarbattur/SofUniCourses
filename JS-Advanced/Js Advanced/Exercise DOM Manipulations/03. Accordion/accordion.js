function toggle() {
    const button = document.getElementsByClassName('button')[0];
    const info = document.getElementById('extra');

    if (info.style.display == 'none') {
        info.style.display = 'block';
        button.innerHTML = 'Less'
    }
    else{
        info.style.display = 'none'
        button.innerHTML = 'More'
    }
}