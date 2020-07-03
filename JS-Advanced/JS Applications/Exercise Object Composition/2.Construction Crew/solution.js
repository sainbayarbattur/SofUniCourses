function main(object){
    if (object.dizziness) {
        let waterNeeded = 0.1 * object.weight * object.experience
        object.levelOfHydrated += waterNeeded
    }
    object.dizziness = false
    return object
}


main({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true })