import { HttpStatusCode } from "@angular/common/http";
import { Books } from "./books";

export interface ApiResponse<T> {
    success: boolean;
    result: Books[];
    StatusCode: HttpStatusCode;
    errorMessages: string;
}