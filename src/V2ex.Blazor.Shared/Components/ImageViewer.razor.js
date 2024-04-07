export function initializeModal(modalRef) {
    const modalOptions = {
        placement: 'center-center',
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
        id: 'image-viewer-modal',
        override: true
    };

    return new Modal(modalRef, modalOptions, instanceOptions);
}

export function initializeSwiper(swiperRef) {
    const swiper = new Swiper(swiperRef, {
        // Optional parameters
        direction: 'horizontal',
        loop: false,
        initialSlide: 0,

        touchStartPreventDefault: false,

        // If we need pagination
        pagination: {
            el: '.swiper-pagination',
        },

        // Navigation arrows
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },

        // And if we need scrollbar
        scrollbar: {
            el: '.swiper-scrollbar',
        },
        on: {
            init: function () {
               
            },
            slideChange: function () {
            },
        },
    });

    return swiper;
}

export function initializePinchZoom(swiperRef) {
    const images = swiperRef.querySelectorAll('.swiper-slide')

    const pinches = Array.from(images)
        .map(img => {
            return new PinchZoom.default(img, {
                draggableUnzoomed: false,
                tapZoomFactor: 2,
                zoomOutFactor: 1.3,
                useMouseWheel: true
            });
        })
    return pinches
}