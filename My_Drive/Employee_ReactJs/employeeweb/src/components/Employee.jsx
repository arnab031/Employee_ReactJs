import React, { useEffect } from "react";
import { useState } from "react";
import {
  addEmployee,
  deleteEmployeeById,
  getEmployeeById,
  updateEmployeeById,
} from "../queries/employee.queries";
import { useParams, useNavigate } from "react-router-dom";

function Employee() {
  const [name, setName] = useState("");
  const [age, setAge] = useState(0);
  const { id } = useParams();
  const navigate = useNavigate();
  useEffect(() => {
    async function fetchData() {
      // You can await here
      const response = await getEmployeeById(id);
      setName(response?.name);
      setAge(response?.age);
      console.log("Res", response);
    }
    if (id) fetchData();
  }, [id]);

  async function updateEmployee(e) {
    e.preventDefault();
    if (id) {
      const data = {
        id,
        name,
        age,
      };
      const response = await updateEmployeeById(id, data);
      if (response) {
        setName(response?.name);
        setAge(response?.age);

        return true;
      } else {
        return false;
      }
    } else {
      const data = {
        name,
        age,
      };
      const response = await addEmployee(data);
      if (response) {
        setName(response?.name);
        setAge(response?.age);

        return true;
      } else {
        return false;
      }
    }
  }
  async function DeleteEmployee(e) {
    e.preventDefault();
    const response = await deleteEmployeeById(id);
    console.log("response", response);
    if (response) {
      console.log("hello");
      navigate("/");
    }
  }
  return (
    <div>
      <form>
        <label form="fname">First Name: </label>
        <input
          type="text"
          id="fname"
          name="fname"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <br />
        <label form="age">Age: </label>
        <input
          type="number"
          id="age"
          name="age"
          value={age}
          onChange={(e) => setAge(e.target.value)}
        />
        <br />
        <button onClick={updateEmployee} type="submit">
          {id ? "Update" : "Add"}
        </button>
        {id ? (
          <button onClick={DeleteEmployee} type="submit">
            Delete
          </button>
        ) : (
          <></>
        )}
      </form>
    </div>
  );
}

export default Employee;
