
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import "./App.css";

function App() {
  return (
    <div>
      <div>
        <BrowserRouter>
          <nav>
            <ul>
              <li>
                <Link to={"/"}>Home</Link>
              </li>
              <li>
                <Link to={"/pages/aluno/listar"}>
                  Listar Alunos{" "}
                </Link>
              </li>
              <li>
                <Link to={"/pages/imc/listar"}>
                  Listar Imc{" "}
                </Link>
              </li>
                <li>
                    <Link to={"/pages/imc/cadastrar"}>
                    Cadastrar Imc{" "}
                    </Link>
              <li>
                <Link to={"/pages/aluno/cadastrar"}>
                  Cadastrar Tarefa{" "}
                </Link>
              </li>
            </ul>
          </nav>
          <Routes>
            <Route path="/" element={<ListarImc />} />
            <Route
              path="/pages/tarefa/listar"
              element={<ListarTarefas />}
            />
            <Route
              path="/pages/tarefa/listarconcluidas"
              element={<ListarTarefasConcluidas />}
            />
          </Routes>
          <footer>
            <p>Desenvolvido por Matheus Feliphe</p>
          </footer>
        </BrowserRouter>
      </div>
    </div>
  );
}

export default App;
