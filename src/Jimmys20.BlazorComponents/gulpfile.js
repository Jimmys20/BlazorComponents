const gulp = require('gulp');
const del = require('del');

const libraries = [
];

function clean() {
    return del('wwwroot/lib');
}

function copy(cb) {
    if (libraries.length > 0) {
        return gulp.src(libraries, { base: 'node_modules' }).pipe(gulp.dest('wwwroot/lib'));
    } else {
        cb();
    }
}

exports.clean = clean;
exports.copy = copy;
exports.default = gulp.series(clean, copy);