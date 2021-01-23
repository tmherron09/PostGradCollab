import { CommentBox } from './Comments'

class App extends React.Component {


    render() {
        return (
            <div id="app">
                <div id="header">
                    <h1>Hello</h1>
                </div>
                <div id="comments">
                    <CommentBox
                        url="/comments"
                        submitUrl="/comments/new"
                        pollInterval={2000}
                    />
                </div>
            </div>
        );
    }
}

ReactDOM.render(
    <App/>,
    document.getElementById('example'),
);