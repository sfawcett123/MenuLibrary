const {  src, dest, series } = require("gulp");
var clean = require('gulp-clean');
var browserify = require('browserify');
var esmify = require('esmify');
var source = require("vinyl-source-stream");

function images( cb ) {
    src('./wwwroot/img/*.*')
            .pipe(dest('dist/img/'));
    cb();
 }

 function css( cb ) {
    src('./wwwroot/css/*.css')
            .pipe(dest('dist/css/'));
    cb();
 }

 function javascripts() {
    return browserify({
        entries: './wwwroot/js/menu.js',
        debug: true,
        standalone: 'menu',
        plugin: [ esmify ]
      })
      .bundle()
      .pipe(source("menu.js"))
      .pipe(dest('dist/js'));
 }

 function cleanup(cb) {
    src('dist/**', {read: false})
        .pipe(clean());
    cb();
 }


 exports.default = series( css , images  , javascripts)