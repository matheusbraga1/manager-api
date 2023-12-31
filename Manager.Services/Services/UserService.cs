﻿using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if (userExists != null)
                throw new DomainException("Já existe um usuário cadastrado com o e-mail informado.");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task Delete(long id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get(id);

            if (user == null)
                throw new DomainException("Não existe nenhum usuário com o ID informado.");

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var allUsers = await _userRepository.GetAll();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var userEmail = await _userRepository.GetByEmail(email);

            if (userEmail == null)
                throw new DomainException("Não existe nenhum usuário com o e-mail informado.");

            return _mapper.Map<UserDTO>(userEmail);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUsersByEmail = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUsersByEmail);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUsersByName = await _userRepository.SearchByName(name);

            return _mapper.Map<List<UserDTO>>(allUsersByName);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            if (userExists == null) 
                throw new DomainException("Não existe nenhum usuário com o ID informado.");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdated = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }
    }
}
