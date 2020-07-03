function lockedProfile() {
    const profiles = document.getElementsByClassName('profile');

    Array.from(profiles).forEach(p => {
        const button = p.getElementsByTagName('button')[0];
        button.addEventListener('click', function(){
            const hiddenFields = p.getElementsByTagName('div')[0];
            const lock = p.getElementsByTagName('input')[0];

            if (lock.checked == false) {
                if (button.textContent == 'Hide it') {
                    button.textContent = 'Show more'
                    hiddenFields.style.display = 'none';
                }
                else{
                    button.textContent = 'Hide it'
                    hiddenFields.style.display = 'block';
                }
            }
        });
    })
}