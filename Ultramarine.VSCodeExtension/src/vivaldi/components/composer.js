import React, { Component } from 'react'
import Strip from './Strip'
import Toolbox from './Toolbox'
import TaskTypes from '../model/TaskTypes'
import Common from '../model/Common'

const initialState = {
  items: [
    {
      id: 1,
      name: 'Create Root Folder',
      type: TaskTypes.CREATE_FOLDER,
      description:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit placeat laboriosam eveniet esse. ',
      path: 'C:/Program Files/Ultramarin/'
    },
    {
      id: 2,
      name: 'Download Application',
      type: TaskTypes.WEB_DOWNLOAD,
      description:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Adipisci beatae in officia distinctio.',
      url: 'http://ultramarin.com/download'
    },
    {
      id: 3,
      name: 'Create Database',
      type: TaskTypes.SQL_EXECUTE,
      description:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Officiis placeat fugit aperiam quaerat recusandae.',
      connectionString: '10.0.10.1/SQL',
      query: 'spCreateDatabase'
    },
    {
      id: 0,
      type: TaskTypes.LANDING_ZONE,
      typeLanded: null
    }
  ],
  taskTypes: [
    {
      name: 'Create Folder',
      type: TaskTypes.CREATE_FOLDER,
      abbr: 'CF',
      icon: 'create_new_folder'
    },
    {
      name: 'SQL Execute',
      type: TaskTypes.SQL_EXECUTE,
      abbr: 'SQL',
      icon: 'storage'
    },
    {
      name: 'Web Download',
      type: TaskTypes.WEB_DOWNLOAD,
      abbr: 'WD',
      icon: 'cloud_download'
    },
    {
      name: 'Generate Code From T4 Template',
      type: TaskTypes.GENERATE_CODE_FROM_T4_TEMPLATE,
      abbr: 'T4',
      icon: 'build'
    },
    {
      name: 'Composite',
      type: TaskTypes.COMPOSITE,
      abbr: 'CM',
      icon: 'local_movies'
    }
  ]
}

class Composer extends Component {
  constructor(props) {
    super(props)
    this.state = initialState
  }

  componentDidMount() {
    window.addEventListener('message', this.handleFileOpen)
  }

  componentWillUnmount() {
    window.removeEventListener('message', this.handleFileOpen)
  }

  handleFileOpen = event => {
    const { generator } = event.data
    const { items } = this.state
    const tasks = generator.tasks.map((task, index) => {
      const type = Object.keys(task)[0]
      return {
        ...task[type],
        id: index,
        type
      }
    })
    const landingZone = items.find(x => x.type === TaskTypes.LANDING_ZONE)

    tasks.push(landingZone)
    this.setState({ items: tasks })
  }

  handleTaskAdded = task => {
    const { items } = this.state
    const newId = Common.newId(items)
    const newItem = {
      ...task,
      id: newId
    }
    let newItems = [...items]
    const landingZone = newItems.find(x => x.type === TaskTypes.LANDING_ZONE)
    landingZone.typeLanded = null
    newItems = newItems.map(item =>
      item.type === TaskTypes.LANDING_ZONE ? newItem : item
    )
    newItems.push(landingZone)
    this.setState({ items: newItems })
  }

  handleTaskLanded = e => {
    const { items } = this.state
    const type = e.dataTransfer.getData('taskType')
    const newItems = [...items]
    const landingZone = newItems.find(x => x.type === TaskTypes.LANDING_ZONE)
    landingZone.typeLanded = type
    this.setState({ items: newItems })
  }

  handleLandingCancelled = () => {
    const { items } = this.state
    const newItems = [...items]
    const landingZone = newItems.find(x => x.type === TaskTypes.LANDING_ZONE)
    landingZone.typeLanded = null
    this.setState({ items: newItems })
  }

  render() {
    const { items, taskTypes } = this.state
    return (
      <div className="container">
        <div className="row">
          <div className="col s7 m8 offset-l1 l7 offset-xl2 xl7">
            <Strip
              items={items}
              onTaskAdded={this.handleTaskAdded}
              onTaskLanded={this.handleTaskLanded}
              onLandingCancelled={this.handleLandingCancelled}
            />
          </div>
          <div className="col s5 m4 l4 xl3">
            <Toolbox taskTypes={taskTypes} />
          </div>
        </div>
      </div>
    )
  }
}

export default Composer
