export class Shape {

    sideA: number = 0;

    constructor() {
    }


    calculatePerimeter(): number {
        return 4 * this.sideA;
    }

    calculateArea(): number {
        return this.sideA * this.sideA;
    }

}
