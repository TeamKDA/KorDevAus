import '../stylesheets/index.scss'

import React from 'react'
import ReactDOM from 'react-dom'
import Hello from './Hello'

const log = message => console.log(message)

log('Hello Jay Kwon')

ReactDOM.render(<Hello />, document.querySelector('#app'))

if (process.env.NODE_ENV === 'development') {
    module.hot.accept();
}