import { UserModel } from "./user.model";

export class PostModel {
    //#region Members
    public ID: string | undefined;
    public Name: string | undefined;
    public Description: string | undefined;
    public CreatedAt: Date | undefined;
    public UpdatedAt: Date | undefined;
    public UserID: string | undefined;
    public User: UserModel | undefined;
    //#endregion
}