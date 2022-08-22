export function enableDragHandle(draggable, handleSelector) {
    var handle = draggable.querySelector(handleSelector);
    var target = false;

    draggable.onmousedown = function (e) {
        target = e.target;
    };

    draggable.ondragstart = function (e) {
        if (!handle.contains(target)) {
            e.preventDefault();
        }
    };
}
