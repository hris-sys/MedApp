(() => {
    let deleteButtons = document.getElementsByClassName('restore-icon-note');

    Array.from(deleteButtons).forEach(element => element.addEventListener('click', function (e) {
        e.preventDefault();
        fetch(this.href)
            .then(response => {
                let messageContainer = this.parentNode.parentNode;
                let messagesContainer = messageContainer.parentNode;
                messagesContainer.removeChild(messageContainer);
            })
    }))
})()