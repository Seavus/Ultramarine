import React, { Component } from 'react'
import CreateFolder from './CreateFolder'
import WebDownload from './WebDownload'
import SqlExecute from './SqlExecute'

// export { default as CreateFolder } from './CreateFolder'
// export { default as WebDownload } from './WebDownload'
// export { default as SqlExecute } from './SqlExecute'

const components = [
  CreateFolder,
  WebDownload,
  SqlExecute
]

class TaskBuilder extends Component {
  state = {
  }
  handleChange = (e) => {
    //console.log(this.state);
    this.setState({
        [e.target.id]: e.target.value
    })
  }
  handleTaskAdded = () => {
    //debugger;
    const {type} = this.props;
    let item = {...this.state};
    item.type = type;
    this.props.onTaskAdded(item);
  }
  render() {
    //console.log('task builder', this.props);
    const {type} = this.props;
    const Item = components.find(i => i.type === type);
    return (
      <Item {...this.props}           
        onChange={this.handleChange} 
        onTaskAdded={this.handleTaskAdded}
      />
    );
  }
}

export default TaskBuilder