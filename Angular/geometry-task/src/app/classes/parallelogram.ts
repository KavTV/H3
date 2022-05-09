import { Rectangle } from "./rectangle";

export class Parallelogram extends Rectangle{

    height:number = 0;

    override calculatePerimeter(): number {
        return 2 * this.sideA + 2* this.sideB;
    }

    override calculateArea(): number {
        return this.sideA * this.height;
    }
}
