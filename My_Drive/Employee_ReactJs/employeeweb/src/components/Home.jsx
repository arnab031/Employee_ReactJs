import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import { getEmployees } from "../queries/employee.queries";
import { Link } from "react-router-dom";

function Home() {
  const [data, setData] = useState();
  useEffect(() => {
    async function fetchData() {
      // You can await here
      const response = await getEmployees();
      // ...
      setData(response);
      console.log("Res", response);
    }
    fetchData();
  }, []);
  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Age</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {data?.map((item, index) => (
            <tr key={index}>
              <td>{item.id}</td>
              <td>{item.name}</td>
              <td>{item.age}</td>
              <td>
                <Link to={`/employee/${item.id}`}>Edit</Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Home;
