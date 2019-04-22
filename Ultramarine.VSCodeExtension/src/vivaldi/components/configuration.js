import React from 'react'
import Generator from './tasks/generator'
import genConfig from '../../tests/samples/repository.gen.json'

const Configuration = () => <Generator {...genConfig} />

export default Configuration
