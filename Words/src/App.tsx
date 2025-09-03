import { Route, Routes } from 'react-router-dom'
import './App.css'
import { HomePage } from './pages/HomePage'
import { AddWordPage } from './pages/AddWord/AddWordPage'
import { DictionaryPage } from './pages/Dictionary/DictionaryPage'
import { EditWordPage } from './pages/EditWord/EditWordPage'
import { TestPage } from './pages/TestPage/TestPage'
import { ResultPage } from './pages/ResultPage'

function App() {

  return (
    <Routes>
      <Route path="/" element={<HomePage />}></Route>
      <Route path="/dictionary" element={<DictionaryPage/>}></Route>
      <Route path="/new-word" element={<AddWordPage/>}></Route>
      <Route path="/edit-word/:id" element={<EditWordPage/>}></Route>
      <Route path="/test" element={<TestPage/>}></Route>
      <Route path="result" element={<ResultPage/>}></Route>
    </Routes>
  )
}

export default App
