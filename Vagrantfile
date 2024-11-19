Vagrant.configure("2") do |config|
  
  # Визначення конфігурації для Ubuntu
  config.vm.define "ubuntu" do |ubuntu|
    ubuntu.vm.box = "bento/ubuntu-22.04"
    ubuntu.vm.hostname = "VagrantVM"
    ubuntu.vm.network "private_network", ip: "192.168.67.26"
    ubuntu.vm.provider "virtualbox" do |vb|
      vb.name = "VagrantVM"
      vb.gui = false
      vb.memory = "5120"
      vb.cpus = 3
    end
    ubuntu.vm.synced_folder ".", "/home/vagrant/project"
    ubuntu.ssh.insert_key = false

    ubuntu.vm.provision "shell", inline: <<-SHELL
      # Видалення існуючих пакетів .NET, якщо вони є
      sudo apt remove -y 'dotnet*' 'aspnet*' 'netstandard*' || true

      # Налаштування apt preferences для ігнорування системних .NET пакетів
      echo "Package: dotnet* aspnet* netstandard*" | sudo tee /etc/apt/preferences.d/dotnet
      echo "Pin: origin \"archive.ubuntu.com\"" | sudo tee -a /etc/apt/preferences.d/dotnet
      echo "Pin-Priority: -10" | sudo tee -a /etc/apt/preferences.d/dotnet
      echo "" | sudo tee -a /etc/apt/preferences.d/dotnet
      echo "Package: dotnet* aspnet* netstandard*" | sudo tee -a /etc/apt/preferences.d/dotnet
      echo "Pin: origin \"security.ubuntu.com\"" | sudo tee -a /etc/apt/preferences.d/dotnet
      echo "Pin-Priority: -10" | sudo tee -a /etc/apt/preferences.d/dotnet

      # Додавання Microsoft репозиторію
      wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
      sudo dpkg -i packages-microsoft-prod.deb
      rm packages-microsoft-prod.deb

      # Оновлення репозиторіїв
      sudo apt-get update

      # Встановлення необхідних інструментів і .NET SDK
      sudo apt-get install -y gpg curl wget apt-transport-https software-properties-common
      sudo apt-get install -y dotnet-sdk-6.0

      # Перевірка встановлення
      dotnet --info || { echo "Installation error .NET SDK"; exit 1; }
    SHELL

    ubuntu.vm.provision "shell", privileged: false, inline: <<-SHELL
      # Додавання BaGet як джерела NuGet
      dotnet nuget add source http://10.0.2.2:5000/v3/index.json -n "BaGet"
      
      # Встановлення інструмента MKrutsenko
      dotnet tool install -g IvanetsLab4 --version 1.0.0 --add-source http://10.0.2.2:5000/v3/index.json

      # Додавання інструментів до PATH
      echo 'export PATH="$PATH:$HOME/.dotnet/tools"' >> ~/.bashrc
      source ~/.bashrc

      # Перевірка встановлення інструмента
      IvanetsLab4 --help || { echo "IvanetsLab4 tool is not installed correctly"; exit 1; }
    SHELL
  end
end
  