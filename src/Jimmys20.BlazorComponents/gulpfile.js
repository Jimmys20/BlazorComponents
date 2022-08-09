const gulp = require('gulp');
const del = require('del');

const libraries = [
    'node_modules/gridstack/dist/**/*'
];

function clean() {
    return del('wwwroot/lib');
}

function copy() {
    return gulp.src(libraries, { base: 'node_modules' }).pipe(gulp.dest('wwwroot/lib'));
}

exports.clean = clean;
exports.copy = copy;
exports.default = gulp.series(clean, copy);