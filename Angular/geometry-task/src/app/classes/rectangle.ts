import { Shape } from "./shape";

export class Rectangle extends Shape{

    sideB: number = 0;

    override calculatePerimeter(): number {
        return 2 * (+this.sideA + +this.sideB);
    }

    override calculateArea(): number {
        return this.sideA * this.sideB;
    }
}
