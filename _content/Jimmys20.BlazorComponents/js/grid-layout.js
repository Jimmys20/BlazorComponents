export function enableDragHandle(draggable, handleSelector) {
    if (!draggable) {
        return;
    }

    const handle = draggable.querySelector(handleSelector);

    if (!handle) {
        return;
    }

    let target = false;

    draggable.onmousedown = function (e) {
        target = e.target;
    };

    draggable.ondragstart = function (e) {
        if (!handle.contains(target)) {
            e.preventDefault();
        }
    };
}
