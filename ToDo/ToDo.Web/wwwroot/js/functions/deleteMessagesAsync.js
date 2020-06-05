(() => {
    let deleteButtons = document.getElementsByClassName('delete-icon');

    Array.from(deleteButtons).forEach(element => element.addEventListener('click', function (e) {
        e.preventDefault();
        fetch(this.href)
            .then(response => {
                let messageContainer = this.parentNode;
                let messagesContainer = messageContainer.parentNode;
                messagesContainer.removeChild(messageContainer);
            })
    }))
})()