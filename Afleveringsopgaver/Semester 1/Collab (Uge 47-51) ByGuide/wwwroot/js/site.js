// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () => {

    const re = /^([\/].*)\//

    document.querySelectorAll('.nav-link').forEach(link => {

        const subPageRe = re.exec(location.pathname.toLowerCase());

        if ((link.getAttribute('href').toLowerCase() === location.pathname.toLowerCase()) || (subPageRe !== null && link.getAttribute('href').toLowerCase() === subPageRe[1])) {
            link.classList.add('active-link');
        } else {
            link.classList.remove('active-link');
        }
    });
})
