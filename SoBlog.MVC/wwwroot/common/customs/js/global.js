function startLoading(element = 'body') {
    $(element).waitMe({
        effect: 'bounce',
        text: 'لطفا منتظر بمانید',
        bg: 'rgba(255, 255, 255, 0.7)',
        color: '#000'
    });
}

function closeLoading(element = 'body') {
    $(element).waitMe('hide');
}
