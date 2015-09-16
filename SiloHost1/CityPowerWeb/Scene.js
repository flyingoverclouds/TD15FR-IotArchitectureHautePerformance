var createScene = function () {

    var createWall = function (name, x, y, z, scene, shadowGenerator, brickMaterial) {
        //createBrickBlock
        var brickblock = BABYLON.Mesh.CreateBox(name, 10, scene);
        brickblock.position = new BABYLON.Vector3(x, y, z);
        brickblock.material = brickMaterial;
        shadowGenerator.getShadowMap().renderList.push(brickblock);
    }

    var createWindow = function (name, x, y, z, scene, windowMaterial) {
        //createBrickBlock
        var brickblock = BABYLON.Mesh.CreateBox(name, 10, scene);
        brickblock.position = new BABYLON.Vector3(x, y, z);
        brickblock.material = windowMaterial;
    }

    var isOdd = function (num) {
        return num % 2;
    }

    var createFloor = function (floor, penthouse) {
        var y = (floor + floor) * 10 + 0.25;

        if (!penthouse) {

            createWall("box1" + floor + "1", 0, y, -20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "2", -20, y, 0, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "3", 0, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "4", 20, y, 0, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "5", -20, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "6", 20, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "7", 20, y, -20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "8", -20, y, -20, scene, shadowGenerator, brickMaterial);

            createWall("box1" + floor + "9", -10, y, -20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "10", -20, y, -10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "11", -20, y, 10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "12", -10, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "13", 10, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "14", 20, y, 10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "15", 20, y, -10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "16", 10, y, -20, scene, shadowGenerator, brickMaterial);

            y = (floor + floor + 1) * 10 + 0.25;

            createWall("box2" + floor + "1", 0, y, -20, scene, shadowGenerator, brickMaterial);
            createWall("box2" + floor + "2", -20, y, 0, scene, shadowGenerator, brickMaterial);
            createWall("box2" + floor + "3", 0, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box2" + floor + "4", 20, y, 0, scene, shadowGenerator, brickMaterial);
            createWall("box2" + floor + "5", -20, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box2" + floor + "6", 20, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box2" + floor + "7", 20, y, -20, scene, shadowGenerator, brickMaterial);
            createWall("box2" + floor + "8", -20, y, -20, scene, shadowGenerator, brickMaterial);

            createWindow("window1" + floor + "1", -10, y, -20, scene, materialSphere3);
            createWindow("window1" + floor + "2", -20, y, -10, scene, materialSphere3);
            createWindow("window1" + floor + "3", -20, y, 10, scene, materialSphere3);
            createWindow("window1" + floor + "4", -10, y, 20, scene, materialSphere3);
            createWindow("window1" + floor + "5", 10, y, 20, scene, materialSphere3);
            createWindow("window1" + floor + "6", 20, y, 10, scene, materialSphere3);
            createWindow("window1" + floor + "7", 20, y, -10, scene, materialSphere3);
            createWindow("window1" + floor + "8", 10, y, -20, scene, materialSphere3);
        }
        if (penthouse) {
            createWall("box1" + floor + "1", 0, y, -20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "2", -20, y, 0, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "3", 0, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "4", 20, y, 0, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "5", -20, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "6", 20, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "7", 20, y, -20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "8", -20, y, -20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "9", -10, y, -20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "10", -20, y, -10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "11", -20, y, 10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "12", -10, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "13", 10, y, 20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "14", 20, y, 10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "15", 20, y, -10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "16", 10, y, -20, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "17", -10, y, 10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "18", 0, y, 10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "19", 10, y, 10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "20", 10, y, 0, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "21", 10, y, -10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "22", 0, y, -10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "23", -10, y, -10, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "24", -10, y, 0, scene, shadowGenerator, brickMaterial);
            createWall("box1" + floor + "25", 0, y, 0, scene, shadowGenerator, brickMaterial);
        }
    }

    var scene = new BABYLON.Scene(engine);

    //light
    var light = new BABYLON.HemisphericLight("dir01", new BABYLON.Vector3(0, 1, 0), scene);


    ////Create an Arc Rotate Camera - aimed negative z this time
    var camera = new BABYLON.ArcRotateCamera("Camera", Math.PI / 2, 1.0, 450, BABYLON.Vector3.Zero(), scene);
    camera.attachControl(canvas, true);


    //Creation of a plane
    var plane = BABYLON.Mesh.CreatePlane("plane", 120, scene);
    plane.position.y = -5;
    plane.rotation.x = Math.PI / 2;

    //Creation of boxes
    var brickMaterial = new BABYLON.StandardMaterial(name, scene);
    var brickTexture = new BABYLON.BrickProceduralTexture(name + "text", 512, scene);
    brickTexture.numberOfBricksHeight = 2;
    brickTexture.numberOfBricksWidth = 3;
    brickMaterial.diffuseTexture = brickTexture;

    //Creation of a material with an image texture
    var materialSphere3 = new BABYLON.StandardMaterial("texture3", scene);
    materialSphere3.diffuseTexture = new BABYLON.Texture("textures/window.png", scene);

    //Applying some shadows
    var shadowGenerator = new BABYLON.ShadowGenerator(1024, light);

    var penthouse = 7;
    for (var i = 0; i <= penthouse; i++) {
        if (i == penthouse) {
            createFloor(i, true);
        }
        else {
            createFloor(i, false);
        }
    }

    //Apply the materials to meshes
    //Creation of a repeated textured material
    var materialPlane = new BABYLON.StandardMaterial("texturePlane", scene);
    materialPlane.diffuseTexture = new BABYLON.Texture("textures/bitume.jpg", scene);
    materialPlane.diffuseTexture.uScale = 50.0;//Repeat 5 times on the Vertical Axes
    materialPlane.diffuseTexture.vScale = 50.0;//Repeat 5 times on the Horizontal Axes
    materialPlane.backFaceCulling = false;//Allways show the front and the back of an element

    plane.material = materialPlane;

    return scene;
};


var myTimer = function() {

    $.getJSON('http://orleanscitypower.cloudapp.net/api/powernetwork/GetBuilding?id=1', function (data) {
        //data is the JSON string
        var apparts = data.Appartments;

        var materialOff = new BABYLON.StandardMaterial("textureOff", scene);
        materialOff.diffuseTexture = new BABYLON.Texture("textures/window.png", scene);

        var materialGreen = new BABYLON.StandardMaterial("textureGreen", scene);
        materialGreen.diffuseTexture = new BABYLON.Texture("textures/green.png", scene);

        var materialYellow = new BABYLON.StandardMaterial("textureYellow", scene);
        materialYellow.diffuseTexture = new BABYLON.Texture("textures/yellow.png", scene);

        var materialOrange = new BABYLON.StandardMaterial("textureOrange", scene);
        materialOrange.diffuseTexture = new BABYLON.Texture("textures/orange.png", scene);

        var materialRed = new BABYLON.StandardMaterial("textureRed", scene);
        materialRed.diffuseTexture = new BABYLON.Texture("textures/red.png", scene);

        var materialBlack = new BABYLON.StandardMaterial("textureBlack", scene);
        materialBlack.diffuseTexture = new BABYLON.Texture("textures/black.png", scene);

        for (var i = 0; i < apparts.length; i++) {
            var result = scene.getActiveMeshes();
            for (var j = 0; j < result.length; j++) {
                var numAppart = apparts[i].Id;
                if (result.data[j].name == "window" + numAppart) {
                    if (apparts[i].TotalPower == 0) {
                        result.data[j].material = materialOff;
                    }
                    else if (apparts[i].TotalPower > 0 && apparts[i].TotalPower < 1000 * 15) {
                        result.data[j].material = materialGreen;
                    }
                    else if (apparts[i].TotalPower >= 1000 * 15 && apparts[i].TotalPower < 2000 * 15) {
                        result.data[j].material = materialYellow;
                    }
                    else if (apparts[i].TotalPower >= 2000 * 15 && apparts[i].TotalPower < 3000 * 15) {
                        result.data[j].material = materialOrange;
                    }
                    else if (apparts[i].TotalPower >= 3000 * 15 && apparts[i].TotalPower < 4500 * 15) {
                        result.data[j].material = materialRed;
                    }
                    else if (apparts[i].TotalPower >= 4500 * 15) {
                        result.data[j].material = materialBlack;
                    }
                }
            }
        }
    });
}
