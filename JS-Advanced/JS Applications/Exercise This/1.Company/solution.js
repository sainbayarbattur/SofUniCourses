class Company {
    constructor(){
       this.departments = []  
    }
 
    addEmployee(username, salary, position, department){
       if (!username || !salary || !position || !department) {
          throw new Error('Invalid input!')
       }
 
       if (Number(salary) < 0) {
          throw new Error(' Invalid input!')
       }
 
       if (!this.departments.map(d => d.department).includes(department)) {
          this.departments.push({department:department, employee:[]})
       }
 
       this.departments.find(d => d.department === department).employee.push({username, salary, position})
 
       return `New employee is hired. Name: ${username}. Position: ${position}`
    }
 
    bestDepartment(){
       const reducer = (accumulator, currentValue) => accumulator + currentValue;
       let bestDepartment = this.departments.sort(d => d.employee.map(e => e.salary).reduce(reducer))[0]
 
       let stringToReturn = `Best Department is: ${bestDepartment.department}\n`
 
       stringToReturn += `Average salary: ${(bestDepartment.employee.map(e => e.salary).reduce(reducer) / bestDepartment.employee.length).toFixed(2)}\n`
 
       for (let i = 0; i < bestDepartment.employee.sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username)).length; i++) {
          const employee = bestDepartment.employee[i];
          stringToReturn += `${employee.username} ${employee.salary} ${employee.position}\n`
       }
 
       return stringToReturn.trim()
    }
 }