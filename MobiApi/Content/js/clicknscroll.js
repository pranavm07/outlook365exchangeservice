window.onscroll = function(ev) {
    if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight) {
        alert('end of page');
    }
};
document.addEventListener('click', function(e) {
    e = e || window.event;
    alert(e.target)   
}, true);