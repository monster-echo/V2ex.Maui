export function initialize(modalRef) {
    const modalOptions = {
        placement: 'bottom-center',
        backdrop: "dynamic",
        backdropClasses:
            'bg-gray-900/50 dark:bg-gray-900/80 fixed inset-0 z-40',
        closable: true,
        onHide: () => {
            document.body.classList.add('overflow-hidden');
        },
        onShow: () => {
        },
        onToggle: () => {
        },
    };

    const instanceOptions = {
        id: 'popup-menu-modal',
        override: true
    };

    return new Modal(modalRef, modalOptions, instanceOptions);
}