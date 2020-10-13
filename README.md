# ClassRoomApp

# All Departments
query{
  allDepartments{
    name
    professor{
      name
      employment
    }
    students{
   		 name
      subjects{
        name
      }
    }
  }
}


# With variable
query($departments:[String], $unit: Unit){
  departments(departments:$departments){
    id
    name
    professor{
      id
      name
      height
    }
    students{
      id
      name
      grade
      height(unit:$unit)
      subjects{
        id
        name
      }
    }
  }
}

# Variable
{
  "departments": ["engg", "sci", "eng"],
  "unit": "METERS"
}
