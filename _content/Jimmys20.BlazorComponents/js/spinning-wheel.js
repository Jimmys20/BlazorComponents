export function spin(canvas, angle, duration, componentInstance) {
    const spinAnimation = canvas.animate([{ rotate: `${angle}rad` }], {
        duration: duration,
        easing: 'cubic-bezier(0.2, 0, 0.1, 1)',
        fill: 'forwards'
    });

    spinAnimation.addEventListener('finish', () => {
        componentInstance.invokeMethodAsync('HandleAnimationFinish');
    });
}

export function cancelAnimations(canvas) {
    canvas.getAnimations().forEach(animation => animation.cancel());
}
