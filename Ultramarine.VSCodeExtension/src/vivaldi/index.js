import * as M from 'materialize-css'
import Composer from './components/Composer'
import './style.scss'

document.addEventListener('DOMContentLoaded', () => {
  const elems = document.querySelectorAll('.tooltipped')
  const options = {
    enterDelay: 1000,
    position: 'right',
    outDuration: 40
  }
  M.Tooltip.init(elems, options)
})

// export { default as Composer } from './components/composer'
export { default as Navbar } from './components/Navbar'

export default Composer
