function Main(name, age, weight, height){

    let personalInfo = {age:age, weight:weight, height:height};

    let person = {name:name, personalInfo, BMI:0, status:''};
    
    
    person.BMI = Math.round(weight / ((height / 100) * (height / 100)));

    if (person.BMI < 18.5) {
        person.status = 'underweight';
    }
    else if (person.BMI < 25) {
        person.status = 'normal';
    }
    else if (person.BMI < 30) {
        person.status = 'overweight';
    }
    else{
        person.status = 'obese';
        person['recommendation'] = 'admission required';
    }

    return person;
}

console.log(Main('Honey Boo Boo', 9, 57, 137));