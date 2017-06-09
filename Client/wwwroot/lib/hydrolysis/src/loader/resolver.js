'use strict';
Object.defineProperty(exports, "__esModule", { value: true });
require("babel-polyfill");
class Deferred {
    constructor() {
        const self = this;
        this.promise = new Promise(function (resolve, reject) {
            self.resolve = resolve;
            self.reject = reject;
        });
    }
}
exports.Deferred = Deferred;
