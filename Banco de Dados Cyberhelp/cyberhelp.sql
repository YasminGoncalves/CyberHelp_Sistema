-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 06-Jun-2022 às 01:07
-- Versão do servidor: 10.4.20-MariaDB
-- versão do PHP: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `cyberhelp`
--
CREATE DATABASE IF NOT EXISTS `cyberhelp` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `cyberhelp`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `administrador`
--

CREATE TABLE `administrador` (
  `idAdm` int(10) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `senha` varchar(255) NOT NULL,
  `foto` blob DEFAULT NULL,
  `idEmpresa` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `administrador`
--

INSERT INTO `administrador` (`idAdm`, `nome`, `email`, `senha`, `foto`, `idEmpresa`) VALUES
(8, 'Ana Paula', 'ana@teste.com', '12345', NULL, 6);

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

CREATE TABLE `cliente` (
  `idCliente` int(10) NOT NULL,
  `nome` varchar(225) NOT NULL,
  `telefone` varchar(20) NOT NULL,
  `endereco` varchar(225) DEFAULT NULL,
  `empresa` int(10) NOT NULL,
  `admCadastro` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `cliente`
--

INSERT INTO `cliente` (`idCliente`, `nome`, `telefone`, `endereco`, `empresa`, `admCadastro`) VALUES
(1, 'Yasmin Gonçalves', '(11) 9 9999-6734', 'Rua Dois, número 52 - Jardim São Luís', 1, 1),
(3, 'Cristiane', '(11) 95435-2562', 'Rua Um, número 13 - Jd são luís', 1, 1),
(10, 'Yasmin', 'Teste', '1', 1, 0),
(11, 'Maria', '1', 'teste', 1, 0),
(13, 'Lucas', '(11) 97678-0983', 'Rua Bolo - N 27', 3, 4);

-- --------------------------------------------------------

--
-- Estrutura da tabela `financas`
--

CREATE TABLE `financas` (
  `id` int(10) NOT NULL,
  `data` varchar(16) NOT NULL,
  `tipo` varchar(10) NOT NULL,
  `descricao` varchar(255) NOT NULL,
  `valor` float NOT NULL,
  `idEmpresa` int(10) NOT NULL,
  `idAdm` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `financas`
--

INSERT INTO `financas` (`id`, `data`, `tipo`, `descricao`, `valor`, `idEmpresa`, `idAdm`) VALUES
(2, '25/05/2022', 'Saída', 'Conta de Luz', 500.98, 1, 1),
(4, '05/06/2022', 'Saída', 'Conta de Luz', 300.5, 5, 6),
(5, '05/06/2022', 'Saída', 'Conta de Luz', 350.99, 6, 8);

-- --------------------------------------------------------

--
-- Estrutura da tabela `observacaofinancas`
--

CREATE TABLE `observacaofinancas` (
  `idObs` int(10) NOT NULL,
  `observacao` varchar(255) DEFAULT NULL,
  `idEmpresa` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `observacaofinancas`
--

INSERT INTO `observacaofinancas` (`idObs`, `observacao`, `idEmpresa`) VALUES
(1, '\n\n', 1),
(4, 'Teste 1\n\n', 2),
(5, 'Teste\n', 4),
(6, 'Teste\n', 6);

-- --------------------------------------------------------

--
-- Estrutura da tabela `pedido`
--

CREATE TABLE `pedido` (
  `idPedido` int(10) NOT NULL,
  `data` varchar(255) NOT NULL,
  `descricao` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  `valor` float NOT NULL,
  `idEmpresa` int(10) NOT NULL,
  `idAdm` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE `produto` (
  `codigoProduto` int(10) NOT NULL,
  `descricao` varchar(255) NOT NULL,
  `quantidade` int(10) DEFAULT NULL,
  `valor` float NOT NULL,
  `idEmpresa` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`codigoProduto`, `descricao`, `quantidade`, `valor`, `idEmpresa`) VALUES
(1, 'Molho de Tomate', 1, 2, 1),
(2, 'Maçã', 12, 1, 1),
(8, 'Bolo', 10, 2.5, 6);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `idEmpresa` int(10) NOT NULL,
  `empresa` varchar(255) NOT NULL,
  `cnpj` varchar(18) NOT NULL,
  `email` varchar(255) DEFAULT NULL,
  `telefone` varchar(16) DEFAULT NULL,
  `login` varchar(255) NOT NULL,
  `senha` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`idEmpresa`, `empresa`, `cnpj`, `email`, `telefone`, `login`, `senha`) VALUES
(1, 'Honda', '6736328782738', 'teste@teste.com', '11989895436', 'honda123', '123'),
(6, 'Doceria Ibirapuera', '77584758598588', 'doceriaibira@teste.com', '(11) 98758-9876', 'DoceriaIbira', 'Dc123');

-- --------------------------------------------------------

--
-- Estrutura da tabela `venda`
--

CREATE TABLE `venda` (
  `idVenda` int(10) NOT NULL,
  `data` varchar(14) NOT NULL,
  `valor` float NOT NULL,
  `bandeira` varchar(30) NOT NULL,
  `parcelas` int(5) NOT NULL,
  `valorLiq` float NOT NULL,
  `taxa` float NOT NULL,
  `idEmpresa` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `venda`
--

INSERT INTO `venda` (`idVenda`, `data`, `valor`, `bandeira`, `parcelas`, `valorLiq`, `taxa`, `idEmpresa`) VALUES
(2, '31/05/2022', 400.87, 'Mastercard', 2, 399.99, 25, 1);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `administrador`
--
ALTER TABLE `administrador`
  ADD PRIMARY KEY (`idAdm`);

--
-- Índices para tabela `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`idCliente`);

--
-- Índices para tabela `financas`
--
ALTER TABLE `financas`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `observacaofinancas`
--
ALTER TABLE `observacaofinancas`
  ADD PRIMARY KEY (`idObs`);

--
-- Índices para tabela `pedido`
--
ALTER TABLE `pedido`
  ADD PRIMARY KEY (`idPedido`);

--
-- Índices para tabela `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`codigoProduto`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idEmpresa`);

--
-- Índices para tabela `venda`
--
ALTER TABLE `venda`
  ADD PRIMARY KEY (`idVenda`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `administrador`
--
ALTER TABLE `administrador`
  MODIFY `idAdm` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de tabela `cliente`
--
ALTER TABLE `cliente`
  MODIFY `idCliente` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de tabela `financas`
--
ALTER TABLE `financas`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `observacaofinancas`
--
ALTER TABLE `observacaofinancas`
  MODIFY `idObs` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `pedido`
--
ALTER TABLE `pedido`
  MODIFY `idPedido` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `produto`
--
ALTER TABLE `produto`
  MODIFY `codigoProduto` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idEmpresa` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `venda`
--
ALTER TABLE `venda`
  MODIFY `idVenda` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
