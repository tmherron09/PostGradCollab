// Just example does not need to be final models.
// json

const exampleCommentJson = {
    "_id": "12345abcdef",
    "commentAuthorName": "Name",
    "commentAuthorEmail": "Email@email.com",
    "emailVisible": true,
    "commentText": "This is my comment."
};

const examplePostJson = {
    "_id": "54321fedcba",
    "Author_Name": "Name",
    "Author_Email": "Email@email.com",
    "Title": "Post title",
    "Tagline": "The tagline or brief of the post.",
    "View_Count": 0,
    "Groupies": 0,
    "GitHub_Link": "Link to Github if we want at end of post",
    "LinkedIn_Link": "Link to LinkedIn if we want at end of post."
}

class Example extends React.Component {

    render() {
        return (
            <div className="Example">
                <h1>Hello the Example has worked!</h1>
                <h3>{exampleCommentJson.commentAuthorEmail}</h3>
            </div>
        );
    }
}

ReactDOM.render(<Example />, document.getElementById('example'));