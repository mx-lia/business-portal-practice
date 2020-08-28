import {Region} from "./region";
import {Func} from "./function";

export interface Salary {
  id: number;
  function: Func;
  region: Region;
  min: number;
  max: number;
}
