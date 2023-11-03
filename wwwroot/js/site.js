//Javascript Bootstrap from: https://sweetalert2.github.io/recipe-gallery/
<script src="sweetalert2.all.min.js"></script>

//Following code is a bootstrap that presents a popup window.
//Default text output is 'Signed in successfully' but could be used for the 'Feedback' task in Exercise 12
const Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 2500,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
})

Toast.fire({
    icon: 'success',
    title: 'Vehicle data updated successfully'
})