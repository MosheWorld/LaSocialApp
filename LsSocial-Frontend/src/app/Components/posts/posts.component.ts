import { Component, OnInit } from '@angular/core';
import { PostModel } from 'src/app/Models/post.model';
import { HttpService } from 'src/app/Services/http.service';
import { DataManagementService } from 'src/app/Services/data-management.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html'
})
export class PostsComponent implements OnInit {
  //#region Members
  name: string | undefined;
  description: string | undefined;

  posts: PostModel[] = [];
  //#endregion

  //#region Initializations
  constructor(private httpService: HttpService,
    public dataManagementService: DataManagementService) { }

  ngOnInit(): void {
    this.GetAllPosts();
  }
  //#endregion

  //#region Public Methods
  public GetAllPosts() {
    this.httpService.GetAll().subscribe(
      (posts) => {
        this.posts = posts;
      },
      (e) => { });
  }

  public CreatePost() {
    let postModel: PostModel = new PostModel();
    postModel.Name = this.name;
    postModel.Description = this.description;
    postModel.UserID = this.dataManagementService.userModel.ID;
    postModel.User = this.dataManagementService.userModel;

    if (!this.isModelValid(postModel)) {
      return;
    }

    this.httpService.CreatePost(postModel).subscribe(
      () => { this.posts.push(postModel); },
      () => { console.log('Fail'); }
    );
  }

  public Delete(post: PostModel, index: number) {
    if (post === null || post === undefined) {
      return;
    }

    this.httpService.DeletePost(post).subscribe(
      () => {
        this.posts.splice(index, 1);
      },
      () => { console.log('Fail'); }
    );
  }
  //#endregion

  //#region Private Methods.
  private isModelValid(postModel: PostModel) {
    if (postModel === null
      || postModel === undefined
      || this.isArgumentNullOrUndefined(postModel.Name)
      || postModel.Name === ''
      || this.isArgumentNullOrUndefined(postModel.Description)
      || postModel.Description === '') {
      return false;
    }
    else {
      return true;
    }
  }

  private isArgumentNullOrUndefined(arg: any) {
    if (arg === null || arg === undefined) {
      return true;
    }
    else {
      return false;
    }
  }
  //#endregion
}