﻿namespace AlphaKids.Application.Posts;

public record PostDto(
    string Title
    , string Preview
    , string Content
    , int Rate
    , IList<CommentDto> Comments
    );

public record CommentDto(
    string Author
    , string Content
    );