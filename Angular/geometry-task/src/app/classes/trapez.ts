import { Parallelogram } from "./parallelogram";

export class Trapez extends Parallelogram {

    sideC: number = 0;
    sideD: number = 0;

    override calculatePerimeter(): number {
        //Added plus in front of the numbers to make sure they got added as example 20+30=50 not 2030
        return +this.sideA + +this.sideB + +this.sideC + +this.sideD;
    }

    override calculateArea(): number {
        return 0.5 * +this.height * (+this.sideA + +this.sideC)
    }
}
