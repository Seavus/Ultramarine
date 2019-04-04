import React, { Component } from 'react'
import Strip from './Strip'
import Toolbox from './Toolbox'
import Common, { TaskTypes, LandingZone } from '../model'

const initialState = {
  items: [
    //   {
    //     id: 1,
    //     name: 'Create Root Folder',
    //     type: TaskTypes.CREATE_FOLDER,
    //     description:
    //       'Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit placeat laboriosam eveniet esse.',
    //     folderPath: 'C:/Program Files/Ultramarin/'
    //   },
    //   {
    //     id: 2,
    //     name: 'Download Application',
    //     type: TaskTypes.WEB_DOWNLOAD,
    //     description:
    //       'Lorem ipsum dolor sit amet consectetur adipisicing elit. Adipisci beatae in officia distinctio.',
    //     url: 'http://ultramarin.com/download'
    //   },
    //   {
    //     id: 3,
    //     name: 'Create Database',
    //     type: TaskTypes.SQL_EXECUTE,
    //     description:
    //       'Lorem ipsum dolor sit amet consectetur adipisicing elit. Officiis placeat fugit aperiam quaerat recusandae.',
    //     connectionString: '10.0.10.1/SQL',
    //     query: 'spCreateDatabase'
    //   },
    //   {
    //     id: 4,
    //     name: 'Create ManagementService.cs',
    //     type: TaskTypes.CREATE_PROJECT_ITEM,
    //     description: 'Create ManagementService.cs file as a project item.',
    //     itemName: 'ManagementService.cs',
    //     folderPath: './',
    //     overwrite: true,
    //     input: 'public class ManagementService { }'
    //   }
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
      icon: 'code'
    },
    {
      name: 'Composite',
      type: TaskTypes.COMPOSITE,
      abbr: 'CM',
      icon: 'local_movies'
    },
    {
      name: 'Create Project Item',
      type: TaskTypes.CREATE_PROJECT_ITEM,
      abbr: 'PI',
      icon: 'library_add'
    }
  ]
}

class Composer extends Component {
  constructor(props) {
    super(props)
    console.log('composer constructor')
    const init = { ...initialState }
    init.items.push(new LandingZone())
    this.state = init
  }

  componentDidMount() {
    window.addEventListener('message', this.handleFileOpen)
  }

  componentWillUnmount() {
    window.removeEventListener('message', this.handleFileOpen)
  }

  landingZoneIndex = () => {
    const { items } = this.state
    return items.findIndex(x => x.type === TaskTypes.LANDING_ZONE)
  }

  handleFileOpen = event => {
    const { generator } = event.data
    if (!generator) return
    const tasks = generator.tasks.map((task, index) => {
      const type = Object.keys(task)[0]
      return {
        ...task[type],
        id: index,
        type
      }
    })
    tasks.push(new LandingZone())
    this.setState({ items: tasks })
  }

  handleTaskUpdated = task => {
    const { items } = this.state
    const newTask = { ...task, isEditable: false }
    let newItems
    if (newTask.id === undefined || newTask.id === null) {
      // new task
      newTask.id = Common.newId(items)
      newItems = items.map(x =>
        x.type === TaskTypes.LANDING_ZONE ? newTask : x
      )
      newItems.push(new LandingZone())
    } else {
      // updated task
      newItems = items.map(x => (x.id === task.id ? task : x))
    }
    this.setState({ items: newItems })
  }

  handleTaskLanded = type => {
    // console.log('task landed')
    const { items } = this.state
    const newItems = [...items]
    const landingZone = newItems.find(x => x.type === TaskTypes.LANDING_ZONE)
    landingZone.taskLanded = { type, isEditable: true }
    this.setState({ items: newItems })
  }

  handleTaskUpdateCancelled = id => {
    // console.log('update cancelled.', id)
    const { items } = this.state
    const newItems = items.filter(x => x.type !== TaskTypes.LANDING_ZONE)
    if (id !== null) {
      newItems.find(x => x.id === id).isEditable = false
    }
    newItems.push(new LandingZone())
    this.setState({ items: newItems })
  }

  handleFlyOver = id => {
    const { items } = this.state
    let newItems = [...items]
    const index = newItems.findIndex(x => x.id === id)
    newItems = newItems.filter(x => x.type !== TaskTypes.LANDING_ZONE)
    newItems.splice(index, 0, new LandingZone())
    this.setState({ items: newItems })
  }

  handleLandingCheck = () => {
    // console.log('landing check')
    const { items } = this.state
    const landingZone = items.find(x => x.type === TaskTypes.LANDING_ZONE)
    if (!landingZone || !landingZone.taskLanded) {
      this.handleTaskUpdateCancelled()
    }
  }

  handleTaskEdit = id => {
    console.log('task edit', id)
    const { items } = this.state
    let newItems = [...items]
    const newItem = newItems.find(x => x.id === id)
    newItem.isEditable = true
    newItems = newItems.map(x => (x.id !== id ? x : newItem))
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
              onTaskUpdated={this.handleTaskUpdated}
              onTaskLanded={this.handleTaskLanded}
              onTaskUpdateCancelled={this.handleTaskUpdateCancelled}
              onFlyOver={this.handleFlyOver}
              onTaskEdit={this.handleTaskEdit}
            />
          </div>
          <div className="col s5 m4 l4 xl3">
            <Toolbox
              taskTypes={taskTypes}
              onTaskLanded={this.handleTaskLanded}
              onLandingCheck={this.handleLandingCheck}
            />
          </div>
        </div>
      </div>
    )
  }
}

export default Composer
