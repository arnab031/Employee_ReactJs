import axios from "axios";

const baseUrl = "http://localhost:28729/";
export async function getEmployees() {
  const response = await axios({
    method: "GET",
    url: `${baseUrl}Employee`,
  }).catch((err) => {
    console.log(err);
  });

  console.log("Get All Employees response => ", response);

  if (response && response.data) {
    return response.data;
  }

  return null;
}
export async function getEmployeeById(id) {
  const response = await axios({
    method: "GET",
    url: `${baseUrl}Employee/${id}`,
  }).catch((err) => {
    console.log(err);
  });

  console.log("Get single employee response => ", response);

  if (response && response.data) {
    return response.data;
  }

  return null;
}
export async function updateEmployeeById(id, employee) {
  const response = await axios({
    // headers: {
    //   Authorization: `Bearer ${accessToken}`,
    // },
    method: "PUT",
    url: `${baseUrl}Employee/${id}`,
    data: employee,
  }).catch((err) => {
    console.log(err);
  });

  console.log("Update employee response => ", response);

  if (response && response.data) {
    return response.data;
  }

  return null;
}
export async function addEmployee(employee) {
  const response = await axios({
    method: "POST",
    url: `${baseUrl}Employee`,
    data: employee,
  }).catch((err) => {
    console.log(err);
  });

  console.log("Add employee response => ", response);

  if (response && response.data) {
    return response.data;
  }

  return null;
}
export async function deleteEmployeeById(id) {
    const response = await axios({
      method: "DELETE",
      url: `${baseUrl}Employee/${id}`,
      //data: employee,
    }).catch((err) => {
      console.log(err);
    });
  
    console.log("Delete employee response => ", response);
  
    if (response && response.data) {
      return response.data;
    }
  
    return null;
  }
